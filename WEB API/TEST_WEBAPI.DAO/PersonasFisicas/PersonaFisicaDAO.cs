using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEST_WEBAPI.DAL;

namespace TEST_WEBAPI.DAO.PersonasFisicas
{
    public class PersonaFisicaDAO
    {
        public List<TESTDTO.PersonaFisicaDTO> ConsultarPersonaFisica()
        {
            List<TESTDTO.PersonaFisicaDTO> lista = new List<TESTDTO.PersonaFisicaDTO>();
            try
            {
                using (TEST_DEVEntities context = new TEST_DEVEntities())
                {
                    var persona = context.Tb_PersonasFisicas.Where(x => x.Activo == true).ToList();
                    foreach (var p in persona)
                    {
                        TESTDTO.PersonaFisicaDTO dto = new TESTDTO.PersonaFisicaDTO()
                        {
                            IdPersonaFisica = p.IdPersonaFisica,
                            FechaRegistro = (DateTime)p.FechaRegistro,
                            FechaActualizacion = (p.FechaActualizacion == null) ? DateTime.MinValue : (DateTime) p.FechaActualizacion,
                            Nombre = p.Nombre,
                            ApellidoPaterno = p.ApellidoPaterno,
                            ApellidoMaterno = p.ApellidoMaterno,
                            RFC = p.RFC,
                            FechaNacimiento = (DateTime)p.FechaNacimiento,
                            UsuarioAgrega = (int)p.UsuarioAgrega,
                            Activo = (bool)p.Activo
                        };
                        lista.Add(dto);
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return lista;
        }
        public TESTDTO.PersonaFisicaDTO ConsultarPersonaFisica(TESTDTO.PersonaFisicaDTO p)
        {
            try
            {
                using (TEST_DEVEntities context = new TEST_DEVEntities())
                {
                    var persona = context.Tb_PersonasFisicas.Where(x => x.IdPersonaFisica == p.IdPersonaFisica).FirstOrDefault();
                    p.FechaRegistro = (DateTime)persona.FechaRegistro;
                    p.FechaActualizacion = (persona.FechaActualizacion == null) ? DateTime.MinValue : (DateTime)persona.FechaActualizacion;
                    p.Nombre = persona.Nombre;
                    p.ApellidoPaterno = persona.ApellidoPaterno;
                    p.ApellidoMaterno = persona.ApellidoMaterno;
                    p.RFC = persona.RFC;
                    p.FechaNacimiento = (DateTime)persona.FechaNacimiento;
                    p.UsuarioAgrega = (int)persona.UsuarioAgrega;
                    p.Activo = (bool)persona.Activo;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return p;
        }
        public TESTDTO.Response AgregarPersonaFisica(TESTDTO.PersonaFisicaDTO p)
        {
            TESTDTO.Response persona = new TESTDTO.Response();
            try
            {
                using (TEST_DEVEntities context = new TEST_DEVEntities())
                {
                    persona = context.Database.SqlQuery<TESTDTO.Response>("sp_AgregarPersonaFisica @Nombre, @ApellidoPaterno, @ApellidoMaterno, @RFC, @FechaNacimiento, @UsuarioAgrega"
                        , new SqlParameter("@Nombre", p.Nombre)
                        , new SqlParameter("@ApellidoPaterno", p.ApellidoPaterno)
                        , new SqlParameter("@ApellidoMaterno", p.ApellidoMaterno)
                        , new SqlParameter("@RFC", p.RFC)
                        , new SqlParameter("@FechaNacimiento", p.FechaNacimiento)
                        , new SqlParameter("@UsuarioAgrega", p.UsuarioAgrega)
                        )
                        .SingleOrDefault();
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return persona;
        }
        public TESTDTO.Response ActualizarPersonaFisica(TESTDTO.PersonaFisicaDTO p)
        {
            TESTDTO.Response persona = new TESTDTO.Response();
            try
            {
                using (TEST_DEVEntities context = new TEST_DEVEntities())
                {
                    persona = context.Database.SqlQuery<TESTDTO.Response>("sp_ActualizarPersonaFisica @IdPersonaFisica, @Nombre, @ApellidoPaterno, @ApellidoMaterno, @RFC, @FechaNacimiento, @UsuarioAgrega"
                        , new SqlParameter("@IdPersonaFisica", p.IdPersonaFisica)
                        , new SqlParameter("@Nombre", p.Nombre)
                        , new SqlParameter("@ApellidoPaterno", p.ApellidoPaterno)
                        , new SqlParameter("@ApellidoMaterno", p.ApellidoMaterno)
                        , new SqlParameter("@RFC", p.RFC)
                        , new SqlParameter("@FechaNacimiento", p.FechaNacimiento)
                        , new SqlParameter("@UsuarioAgrega", p.UsuarioAgrega)
                        )
                        .SingleOrDefault();
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return persona;
        }
        public TESTDTO.Response EliminarPersonaFisica(int id)
        {
            TESTDTO.Response persona = new TESTDTO.Response();
            try
            {
                using (TEST_DEVEntities context = new TEST_DEVEntities())
                {
                    persona = context.Database.SqlQuery<TESTDTO.Response>("sp_EliminarPersonaFisica @IdPersonaFisica"
                        , new SqlParameter("@IdPersonaFisica", id))
                        .SingleOrDefault();
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return persona;
        }
    }
}
