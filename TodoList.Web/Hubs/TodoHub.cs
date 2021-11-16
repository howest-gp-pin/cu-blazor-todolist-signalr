using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Web.Domain;

namespace TodoList.Web.Hubs
{
    public class TodoHub : Hub
    {

        public async Task AddTodo(TodoItem todoItem)
        {
            await this.Clients.Others.SendAsync("RemoteItemAdded", todoItem);
        }
    }
}
