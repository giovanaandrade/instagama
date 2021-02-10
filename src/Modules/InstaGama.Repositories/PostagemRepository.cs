using InstaGama.Domain.Entities;
using InstaGama.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace InstaGama.Repositories
{
    public class PostagemRepository : IPostagemRepository
{
	private readonly IConfiguration _configuration;

	public PostagemRepository(IConfiguration configuration)
	{
		 _configuration = configuration;
	}

public async Task<Postagem> GetByIdAsync(int id)
{
    using (var con = new SqlConnection(_configuration["ConnectionString"]))
    {
        var sqlCmd = @$"SELECT 
                                     p.Id,
	                                 p.Texto,
                                     p.DataPostagem,
                                     p.Foto,
                                     u.Id as UserId,
                                FROM 
	                                Postagem p
                                INNER JOIN 
	                                User u ON u.Id = p.UserId
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
                        var postagem = new Postagem(reader["Texto"].ToString(),
                                                    reader["Foto"].ToString(),
                                                    new User(int.Parse(reader["UserId"].ToString())));

                postagem.SetId(int.Parse(reader["Id"].ToString()));

                return postagem;
            }

            return default;
        }
    }
}
}
}
