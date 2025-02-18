using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientService.IHttpService.Contract
{
    public  interface IHttpClientService
    {
        Task<T> GetTAsync<T>(string url);
        Task<T> PostAsync<T>(string url, Object obj);   
        Task<T> PutAsync<T>(string requestUri,Object obj);
        Task<T> DeleteAsync<T>(String requestUri);
    }
}
