using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chatapp_react_signalR.Models;
using Microsoft.AspNetCore.SignalR;

namespace chatapp_react_signalR.Hubs
{
    public class ChatHub : Hub
    {
        private readonly string _botUser;

        public ChatHub()
        {
            _botUser = "MyChat Bot";
        }

        //Join room method: when a user submits a name and a room they want to join
        public async Task JoinRoom(UserConnection userConnection)
        {
            //Adding members to a group
            await Groups.AddToGroupAsync(Context.ConnectionId, userConnection.Room);

            //this sends it to every client, but what we want to do is send it only to members of a group
            // await Clients.All.SendAsync("recieveMessage", _botUser, 
            //     $"{userConnection.User} has joined the {userConnection.Room}");

            //this will send the messge to clients connected in the group
            await Clients.Group(userConnection.Room).SendAsync("ReceiveMessage", _botUser, 
                $"{userConnection.User} has joined the {userConnection.Room}");
        }
    }
}