using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Bruna.Danilo.Testers.Settings;

namespace Bruna.Danilo.Testers.Logs
{
    public class Logger
    {
		private LogsContext _logsContext;

		public Logger(LogsContext logsContext){
			this._logsContext = logsContext;
		}

		public async Task<int> SaveAsync(LogTypesEnum logType,
							   string message,
							  string stackTrace,
							  string moreInfo,
							  string userId,
							   int? parentLogId)
		{
			try
			{
    			var log = new Entities.Logs()
    			{
    				LogTypeId = (int)logType,
    				Message = message,
    				MoreInfo = moreInfo,
    				ParentLogId = parentLogId,
    				StackTrace = stackTrace,
    				TimeStamp = DateTime.Now,
    				UserId = userId
    			};
    			this._logsContext.Logs.Add(log);

    			var i = this._logsContext.SaveChangesAsync().Result;

    			return log.Id;
			}
            catch (Exception ex)
            {
				try
				{
					EventLog ev = null;
					if (!EventLog.SourceExists("Bruna.Danilo.Testers"))
                    {
						try
						{
    						EventLog.CreateEventSource(
    							"Bruna.Danilo.Testers", "Bruna.Danilo.Testers.Log");
    						ev = new EventLog("Bruna.Danilo.Testers.Log");                     
                        }
                        catch (Exception)
                        {
							ev = new EventLog();
                        }
                    }

					ev.WriteEntry($"Erro ao salvar log - {ex.Message} - {ex.StackTrace} - {ex.Source}", EventLogEntryType.Error);
					ev.WriteEntry($"Erro tentando salvar o log - {message} - {stackTrace} - {moreInfo} - {userId}", EventLogEntryType.Error);
				}
				catch (Exception){}            
			}

			return 0;
		}

		public async Task<int> InfoAsync(string message,
                      string moreInfo,
                      string userId)
        {
			if (!AppSettings.LogInfo)
				return 0;
			
			return await this.SaveAsync(LogTypesEnum.Info, message, null, moreInfo, userId, null);
        }
        
		public async Task<int> WarningAsync(string message,
              string moreInfo,
              string userId)
        {
			return await this.SaveAsync(LogTypesEnum.Warning, message, null, moreInfo, userId, null);
        }

		public async Task<int> ErrorAsync(string message,
              string moreInfo,
                               string stackTrace,
              string userId,
		                                 int? parentLogId)
        {
			return await this.SaveAsync(LogTypesEnum.Error, message, stackTrace, moreInfo, userId, parentLogId);
        }

		public async Task<int> ErrorAsync(Exception ex,
                               string userId,
		                                int? parentLogId = null)
        {
			
			int parentLogIdTemp = await this.ErrorAsync( ex.Message,ex.Source,ex.StackTrace, userId, parentLogId);
			if (!parentLogId.HasValue)
				parentLogId = parentLogIdTemp;
			
			Exception inner = ex.InnerException;

			while(inner != null){
				await this.ErrorAsync(inner, userId, parentLogId);
			}

			return (parentLogId.HasValue) ? parentLogId.Value : 0;
        }
	}
}
