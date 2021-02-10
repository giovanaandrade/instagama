using System;
using System.Collections.Generic;
using System.Text;

namespace InstaGama.Domain.Entities
{
    public class Curtidas
    {
        public Curtidas (User user, Postagem postagem, bool jaCurtiu)
        {
            User = user;
            Postagem = postagem;
            JaCurtiu = jaCurtiu;

        }

        public int Id { get; private set; }
        public User User { get; private set; }
        public Postagem Postagem { get; private set; }
        public string Type { get; private set; }
        public bool JaCurtiu { get; private set; }

        public void SetId(int id)
        {
            Id = id;
        }

    }
}
