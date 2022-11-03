using DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public static class DataSeed
    {
        public static void Seed(DataContext context)
        {
            var contact1 = new Contact() { Name = "Tú", Img = "/assets/img/profile-pic-l-4.jpg", Date = DateTime.Today, Conversations = null };
            var contact2 = new Contact() { Name = "Linn Ronning", Img = "/assets/img/profile-pic-l-4.jpg", Date = DateTime.Today, Conversations = null };
            var contact3 = new Contact() { Name = "Goldie Mossman", Img = "/assets/img/profile-pic-l-4.jpg", Date = DateTime.Today, Conversations = null };

            var conversation1 = new Conversation()
            {
                Contacts = new List<Contact>() { contact1, contact2 },
                LastMessageTime = DateTime.Today
            };

            var conversation2 = new Conversation()
            {
                Contacts = new List<Contact>() { contact1, contact3 },
                LastMessageTime = DateTime.Today
            };

            var messages = new List<Message>()
            {
            //conversation1
             new Message() { Conversation = conversation1, Sender = 1, Time = new DateTime(2022, 11, 1, 9, 20, 0),Text = "What do you think about our plans for this product launch?" },
             new Message() { Conversation = conversation1, Sender = 1, Time = new DateTime(2022, 11, 1, 9, 29, 0), Text = "It looks to me like you have a lot planned before your deadline. I would suggest you push your deadline back so you have time to run a successful advertising campaign." },
             new Message() { Conversation = conversation1, Sender = 1, Time = new DateTime(2022, 11, 1, 9, 36, 0), Text = "How do you think we should move forward with this project? As you know, we are expected to present it to our clients next week." },
             new Message() { Conversation = conversation1, Sender = 2, Time = new DateTime(2022, 11, 1, 10, 12, 0), Text = "I would suggest you discuss this further with the advertising team." },
             new Message() { Conversation = conversation1, Sender = 2, Time = new DateTime(2022, 11, 1, 18, 20, 0), Text = "I am very busy at the moment and on top of everything, I forgot my umbrella today." },
            //conversation2
             new Message() { Conversation = conversation2, Sender = 1, Time = new DateTime(2022, 11, 1, 9, 25, 0),Text = "What do you think about our plans for this product launch?" },
             new Message() { Conversation = conversation2, Sender = 3, Time = new DateTime(2022, 11, 1, 9, 29, 0), Text = "It looks to me like you have a lot planned before your deadline. I would suggest you push your deadline back so you have time to run a successful advertising campaign." },
             new Message() { Conversation = conversation2, Sender = 3, Time = new DateTime(2022, 11, 1, 9, 36, 0), Text = "How do you think we should move forward with this project? As you know, we are expected to present it to our clients next week." },
             new Message() { Conversation = conversation2, Sender = 1, Time = new DateTime(2022, 11, 1, 10, 12, 0), Text = "I would suggest you discuss this further with the advertising team." },
             new Message() { Conversation = conversation2, Sender = 3, Time = new DateTime(2022, 11, 1, 10, 20, 0), Text = "I am very busy at the moment and on top of everything, I forgot my umbrella today." }
            };


            if (!context.Contact.Any())
            {
                var contacts = new List<Contact>() {
                contact1, contact2, contact3,
                new Contact() { Name = "Laree Munsch", Img = "/assets/img/profile-pic-l-4.jpg", Date = DateTime.Today, Conversations = null },
                new Contact() { Name = "Brynn Bragg", Img = "/assets/img/profile-pic-l-4.jpg", Date = DateTime.Today, Conversations = null },
                new Contact() { Name = "Merle Friberg", Img = "/assets/img/profile-pic-l-4.jpg", Date = DateTime.Today, Conversations = null },
                new Contact() { Name = "Velva Valdovinos", Img = "/assets/img/profile-pic-l-4.jpg", Date = DateTime.Today, Conversations = null },
                new Contact() { Name = "Dusti Gioia", Img = "/assets/img/profile-pic-l-4.jpg", Date = DateTime.Today, Conversations = null },
                new Contact() { Name = "Philip Nelms", Img = "/assets/img/profile-pic-l-4.jpg", Date = DateTime.Today, Conversations = null },
                new Contact() { Name = "Mary Otte", Img = "/assets/img/profile-pic-l-4.jpg", Date = DateTime.Today, Conversations = null },
                new Contact() { Name = "Janene Thies", Img = "/assets/img/profile-pic-l-4.jpg", Date = DateTime.Today, Conversations = null },
                new Contact() { Name = "Bao Hathaway", Img = "/assets/img/profile-pic-l-4.jpg", Date = DateTime.Today, Conversations = null },
                new Contact() { Name = "Ramiro Borak", Img = "/assets/img/profile-pic-l-4.jpg", Date = DateTime.Today, Conversations = null }
                };
                context.AddRange(contacts);
            }

            if (!context.Conversation.Any())
                context.AddRange(conversation1, conversation2);

            if (!context.Message.Any())
                context.AddRange(messages);

            context.SaveChanges();
        }
    }
}