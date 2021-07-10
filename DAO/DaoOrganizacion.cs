﻿using DTO;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class DaoOrganizacion : DaoB
    {
        public DtoOrganizacion Usp_Organizacion_Insert(DtoB dtoBase)
        {
            DtoOrganizacion dto = (DtoOrganizacion)dtoBase;
            SqlParameter[] pr = new SqlParameter[6];
            try
            {
                pr[0] = new SqlParameter("@IdOrganizacion", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                pr[1] = new SqlParameter("@NombreOrganizacion", SqlDbType.VarChar, 200)
                {
                    Value = (V_ValidaPrNull(dto.NombreOrganizacion))
                };
                pr[2] = new SqlParameter("@Departamento", SqlDbType.VarChar, 100)
                {
                    Value = (V_ValidaPrNull(dto.Departamento))
                };
                pr[3] = new SqlParameter("@Distrito", SqlDbType.VarChar, 100)
                {
                    Value = (V_ValidaPrNull(dto.Distrito))
                };
                pr[4] = new SqlParameter("@Capacidad", SqlDbType.Int)
                {
                    Value = (V_ValidaPrNull(dto.Capacidad))
                };
                pr[5] = new SqlParameter("@UsuarioCreacionId", SqlDbType.Int)
                {
                    Value = (V_ValidaPrNull(dto.UsuarioCreacionId))
                };
                pr[6] = new SqlParameter("@msj", SqlDbType.VarChar, 100)
                {
                    Direction = ParameterDirection.Output
                };
                SqlHelper.ExecuteNonQuery(ObjCn, CommandType.StoredProcedure, "Usp_Organizacion_Insert", pr);
            }
            catch (Exception ex)
            {
                dto.LugarError = ex.StackTrace;
                dto.ErrorEx = ex.Message;
                dto.ErrorMsj = "Error al insertar Organizacion";
            }
            ObjCn.Close();
            return dto;
        }
        public ClassResultV Usp_Organizacion_SelectAll(DtoB dtoBase)
        {
            ClassResultV cr = new ClassResultV();
            var dto = (DtoOrganizacion)dtoBase;
            SqlParameter[] pr = new SqlParameter[1];
            try
            {
                pr[0] = new SqlParameter("@Criterio", SqlDbType.VarChar, 300)
                {
                    Value = (dto.Criterio)
                };
                pr[1] = new SqlParameter("@IB_Estado", SqlDbType.Bit)
                {
                    Value = (dto.IB_Estado)
                };

                SqlDataReader reader = SqlHelper.ExecuteReader(ObjCn, CommandType.StoredProcedure, "Usp_Organizacion_SelectAll", pr);

                cr.List = new List<DtoB>();
                while (reader.Read())
                {
                    cr.List.Add(new DtoOrganizacion
                    {
                        IdOrganizacion = GetValue("IdPaciente", reader).ValueInt32,
                        NombreOrganizacion = GetValue("NombreOrganizacion", reader).ValueString,
                        Departamento = GetValue("Departamento", reader).ValueString,
                        Distrito = GetValue("Distrito", reader).ValueString,
                        Capacidad = GetValue("Capacidad", reader).ValueInt32,
                        UsuarioCreacionId = GetValue("UsuarioCreacionId", reader).ValueInt32,
                        FechaCreacion = GetValue("FechaCreacion", reader).ValueDateTime,
                        UsuarioModificacionId = GetValue("UsuarioModificacionId", reader).ValueInt32,
                        FechaModificacion = GetValue("FechaModificacion", reader).ValueDateTime,
                        IB_Estado = GetValue("IB_Estado", reader).ValueBool,
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                cr.LugarError = ex.StackTrace;
                cr.ErrorEx = ex.Message;
                cr.ErrorMsj = "Error al consultar organizaciones";
            }
            ObjCn.Close();
            return cr;
        }
        public ClassResultV Usp_Paciente_Update_ByIdPaciente(DtoB dtoBase)
        {
            DtoPaciente dto = (DtoPaciente)dtoBase;
            ClassResultV cr = new ClassResultV();
            SqlParameter[] pr = new SqlParameter[9];
            try
            {
                pr[0] = new SqlParameter("@IdPaciente", SqlDbType.Int)
                {
                    Value = (dto.IdPaciente)
                };
                pr[1] = new SqlParameter("@Nombres", SqlDbType.VarChar, 100)
                {
                    Value = (V_ValidaPrNull(dto.Nombres))
                };
                pr[2] = new SqlParameter("@Apellidos", SqlDbType.VarChar, 100)
                {
                    Value = (V_ValidaPrNull(dto.Apellidos))
                };
                pr[3] = new SqlParameter("@IN_Tipodoc", SqlDbType.Int)
                {
                    Value = (V_ValidaPrNull(dto.IN_Tipodoc))
                };
                pr[4] = new SqlParameter("@Numdoc", SqlDbType.VarChar, 20)
                {
                    Value = (V_ValidaPrNull(dto.Numdoc))
                };
                pr[5] = new SqlParameter("@IN_TipoSeguro", SqlDbType.Int)
                {
                    Value = (V_ValidaPrNull(dto.IN_TipoSeguro))
                };
                pr[6] = new SqlParameter("@IN_EstadoPaciente", SqlDbType.Int)
                {
                    Value = (V_ValidaPrNull(dto.IN_EstadoPaciente))
                };
                pr[7] = new SqlParameter("@UsuarioModificacionId", SqlDbType.Int)
                {
                    Value = (V_ValidaPrNull(dto.UsuarioModificacionId))
                };
                pr[8] = new SqlParameter("@msj", SqlDbType.VarChar, 100)
                {
                    Direction = ParameterDirection.Output
                };
                SqlHelper.ExecuteNonQuery(ObjCn, CommandType.StoredProcedure, "Usp_Paciente_Update_ByIdPaciente", pr);
                if (!String.IsNullOrEmpty(Convert.ToString(pr[8].Value)))
                {
                    cr.ErrorMsj = Convert.ToString(pr[8].Value);
                    cr.LugarError = "Usp_Paciente_Update_ByIdPaciente";
                }
            }
            catch (Exception ex)
            {
                cr.LugarError = ex.StackTrace;
                cr.ErrorEx = ex.Message;
                cr.ErrorMsj = "Error al actualizar los datos del paciente";
            }
            ObjCn.Close();
            return cr;
        }
        public DtoPaciente Usp_Paciente_SelectOne(DtoB dtoBase)
        {
            DtoPaciente dto = (DtoPaciente)dtoBase;
            SqlParameter[] pr = new SqlParameter[1];

            try
            {
                pr[0] = new SqlParameter("@IdPaciente", SqlDbType.Int)
                {
                    Value = (dto.IdPaciente)
                };

                SqlDataReader reader = SqlHelper.ExecuteReader(ObjCn, CommandType.StoredProcedure, "Usp_Paciente_SelectOne", pr);

                //cr.List = new List<DtoB>();
                if (reader.Read())
                {
                    dto = new DtoPaciente
                    {
                        IdPaciente = GetValue("IdPaciente", reader).ValueInt32,
                        Nombres = GetValue("Nombres", reader).ValueString,
                        Apellidos = GetValue("Apellidos", reader).ValueString,
                        IN_Tipodoc = GetValue("IN_Tipodoc", reader).ValueInt32,
                        Numdoc = GetValue("Numdoc", reader).ValueString,
                        IN_TipoSeguro = GetValue("IN_TipoSeguro", reader).ValueInt32,
                        IN_EstadoPaciente = GetValue("IN_EstadoPaciente", reader).ValueInt32,
                        UsuarioCreacionId = GetValue("UsuarioCreacionId", reader).ValueInt32,
                        FechaCreacion = GetValue("FechaCreacion", reader).ValueDateTime,
                        UsuarioModificacionId = GetValue("UsuarioModificacionId", reader).ValueInt32,
                        FechaModificacion = GetValue("FechaModificacion", reader).ValueDateTime,
                        IB_Estado = GetValue("IB_Estado", reader).ValueBool,
                        Credencial = GetValue("Credencial", reader).ValueString,
                        OrganizacionId = GetValue("OrganizacionId", reader).ValueInt32,
                        NombreTipodoc = GetValue("NombreTipodoc", reader).ValueString,
                        NombreTipoSeguro = GetValue("NombreTipoSeguro", reader).ValueString,
                        NombreEstadoPaciente = GetValue("NombreEstadoPaciente", reader).ValueString
                    };
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                dto.LugarError = ex.StackTrace;
                dto.ErrorEx = ex.Message;
                dto.ErrorMsj = "Error en Usp_Paciente_SelectOne";
            }
            ObjCn.Close();
            return dto;
        }
    }
}
