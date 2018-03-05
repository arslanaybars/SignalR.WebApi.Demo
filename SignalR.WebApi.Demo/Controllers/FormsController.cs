using Microsoft.AspNet.SignalR.Client;
using SignalR.WebApi.Demo.Data;
using SignalR.WebApi.Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace SignalR.WebApi.Demo.Controllers
{
    public class FormsController : ApiController
    {
        // POST: api/Forms
        [HttpPost]
        public IHttpActionResult Post([FromBody]FormApiRequestModel request)
        {
            if (!ModelState.IsValid) { /*error*/ }

            try
            {
                using (var ctx = new DemoContext())
                {
                    // retrieve related by new form request
                    var requestUserIds = request.Users.Select(y => y.Id);
                    var relatedUsers = ctx.Users.Where(x => requestUserIds.Contains(x.Id)).ToList();

                    var recentForm = new Form
                    {
                        Title = request.Title,
                        Description = request.Description,
                        Content = request.Content,
                        CreateTime = request.CreateTime,
                        Users = relatedUsers
                    };

                    ctx.Forms.Add(recentForm);

                    if (ctx.SaveChanges() > 0)
                    {
                        Triger(recentForm); // -> SignalR websocket
                        return Content(HttpStatusCode.Created, request);
                    }
                }

                return Content(HttpStatusCode.BadRequest, new { error = "error" });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, new { error = ex.Message });
            }
        }
        
        [NonAction]
        public async void Triger(Form form)
        {
            try
            {
                var hubConnection = new HubConnection("http://localhost:49701");
                IHubProxy stockTickerHubProxy = hubConnection.CreateHubProxy("FormsHub");
                await hubConnection.Start(new Microsoft.AspNet.SignalR.Client.Transports.LongPollingTransport());
                stockTickerHubProxy.Invoke("RefreshData", form);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
