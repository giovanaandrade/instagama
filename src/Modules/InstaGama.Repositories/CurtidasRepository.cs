using InstaGama.Domain.Entities;
using InstaGama.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace InstaGama.Repositories
{
    public class CurtidasRepository : ICurtidasRepository
    {
        private readonly IConfiguration _configuration;

        public CurtidasRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Curtidas> GetByIdAsync(int id)
        {
            using (var con = new SqlConnection(_configuration["ConnectionString"]))
            {
                var sqlCmd = @$"SELECT 
                                     c.Id,
	                                 c.Tipo,
                                     c.JaCurtiu,
                                     p.Id as c.PostId,
                                     u.Id as c.UserId,
                                FROM 
	                                Curtidas c
                                INNER JOIN
                                    Postagem p ON p.Id = c.PostId
                                INNER JOIN
                                    User u ON u.Id = c.UserId
                                WHERE 
	                                Id={id}";

                using (var cmd = new SqlCommand(sqlCmd, con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    var reader = await cmd
                                        .ExecuteReaderAsync()
                                        .ConfigureAwait(false);

                    while (reader.Read())
                    {
                        var curtidas = new Curtidas(new User(int.Parse(reader["UserId"].ToString())),
                                                    new Postagem(int.Parse(reader["PostId"].ToString())),
                                                    bool.Parse(reader["JaCurtiu"].ToString()));

                        curtidas.SetId(int.Parse(reader["Id"].ToString()));
                        

                        return curtidas;
                    }

                    return default;
                }
            }
        }
    }
}
