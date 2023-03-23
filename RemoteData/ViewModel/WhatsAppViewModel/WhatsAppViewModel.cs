using System.Collections.ObjectModel;

namespace RemoteData.ViewModel.WhatsAppViewModel
{

    public class Chat
    {
        public ImageSource ProfileImage { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Time { get; set; }
        public int NoofChat { get; set; }
    }


    public class WhatsAppViewModel 
    {
        public ObservableCollection<Chat> Chats { get; set;}

        public WhatsAppViewModel()
        {
            Chats = new ObservableCollection<Chat>()
            {
                new Chat()
                {
                    ProfileImage = "dotnet_bot",
                    Name = "Vinay",
                    Description = "Hey I Am Using WhatsApp",
                    Time = 12.00,
                    NoofChat=5
                },

                new Chat()
                {
                    ProfileImage = "dotnet_bot",
                    Name = "Vinay",
                    Description = "Hey I Am Using WhatsApp",
                    Time = 12.00,
                    NoofChat=5
                },

                new Chat()
                {
                    ProfileImage = "dotnet_bot",
                    Name = "Vinay",
                    Description = "Hey I Am Using WhatsApp",
                    Time = 12.00,
                    NoofChat=5
                },

                new Chat()
                {
                    ProfileImage = "dotnet_bot",
                    Name = "Vinay",
                    Description = "Hey I Am Using WhatsApp",
                    Time = 12.00,
                    NoofChat=5
                },

                new Chat()
                {
                    ProfileImage = "dotnet_bot",
                    Name = "Vinay",
                    Description = "Hey I Am Using WhatsApp",
                    Time = 12.00,
                    NoofChat=5
                },

            };
        }
    }
}
