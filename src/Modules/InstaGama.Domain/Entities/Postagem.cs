using System;

namespace InstaGama.Domain.Entities
{
	public class Postagem
	{
		public Postagem(string text, string photo, User user)
		{
			Text = text;
			Photo = photo;
			DataPostagem = DateTime.Now;
			User = user;
		}

		public Postagem(int id)
        {
			Id = id;
        }


		public int Id { get; private set; }
		public User User { get; private set; }
		public string Text { get; private set; }
		public string Photo { get; private set; }
		public DateTime DataPostagem { get; private set; }

		public void SetId(int id)
		{
			Id = id;
		}

}


}

