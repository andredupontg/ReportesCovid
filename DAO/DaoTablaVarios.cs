﻿using DTO;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class DaoTablaVarios : DaoB
    {
        public ClassResultV Usp_TablaVarios_SelectAll(DtoB dtoBase)
        {
            ClassResultV cr = new ClassResultV();
            var dto = (DtoTablaVarios)dtoBase;
            SqlParameter[] pr = new SqlParameter[2];
            try
            {
                pr[0] = new SqlParameter("@TipoAtributo", SqlDbType.VarChar, 200)
                {
                    Value = (dto.TipoAtributo)
                };
                pr[1] = new SqlParameter("@EntidadTabla", SqlDbType.VarChar, 200)
                {
                    Value = (dto.EntidadTabla)
                };

                SqlDataReader reader = SqlHelper.ExecuteReader(ObjCn, CommandType.StoredProcedure, "Usp_TablaVarios_SelectAll", pr);

                cr.List = new List<DtoB>();
                while (reader.Read())
                {
                    cr.List.Add(new DtoTablaVarios
                    {
                        IdTabVarios= GetValue("IdTabVarios", reader).ValueInt32,
                        Valor = GetValue("Valor", reader).ValueString,
                        Descripcion = GetValue("Descripcion", reader).ValueString,
                        TipoAtributo = GetValue("TipoAtributo", reader).ValueString,
                        EntidadTabla = GetValue("EntidadTabla", reader).ValueString,
                        UsuarioCreacionId = GetValue("UsuarioCreacionId", reader).ValueInt32,
                        FechaCreacion = GetValue("FechaCreacion", reader).ValueDateTime,
                        UsuarioModificacionId = GetValue("UsuarioModificacionId", reader).ValueInt32,
                        FechaModificacion = GetValue("FechaModificacion", reader).ValueDateTime,
                        IB_Estado = GetValue("IB_Estado", reader).ValueBool
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                cr.LugarError = ex.StackTrace;
                cr.ErrorEx = ex.Message;
                cr.ErrorMsj = "Error al consultar tabla varios";
            }
            ObjCn.Close();
            return cr;
        }
        public DtoTablaVarios Usp_TablaVarios_Insert(DtoB dtoBase)
        {
            DtoTablaVarios dto = (DtoTablaVarios)dtoBase;
            SqlParameter[] pr = new SqlParameter[6];
            try
            {
                pr[0] = new SqlParameter("@IdTabVarios", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                pr[1] = new SqlParameter("@Valor", SqlDbType.VarChar, 200)
                {
                    Value = (V_ValidaPrNull(dto.Valor))
                };
                pr[2] = new SqlParameter("@Descripcion", SqlDbType.VarChar, 200)
                {
                    Value = (V_ValidaPrNull(dto.Descripcion))
                };
                pr[3] = new SqlParameter("@TipoAtributo", SqlDbType.VarChar, 200)
                {
                    Value = (V_ValidaPrNull(dto.TipoAtributo))
                };
                pr[4] = new SqlParameter("@EntidadTabla", SqlDbType.VarChar, 200)
                {
                    Value = (V_ValidaPrNull(dto.EntidadTabla))
                };
                pr[5] = new SqlParameter("@UsuarioCreacionId", SqlDbType.Int)
                {
                    Value = (V_ValidaPrNull(dto.UsuarioCreacionId))
                };
                SqlHelper.ExecuteNonQuery(ObjCn, CommandType.StoredProcedure, "Usp_TablaVarios_Insert", pr);
                if (pr[0].Value != DBNull.Value)
                {
                    dto.IdTabVarios = Convert.ToInt32(pr[0].Value);
                }
                if (!String.IsNullOrEmpty(Convert.ToString(pr[9].Value)))
                {
                    dto.ErrorMsj = Convert.ToString(pr[9].Value);
                    dto.LugarError = "Usp_TablaVarios_Insert";
                }
            }
            catch (Exception ex)
            {
                dto.LugarError = ex.StackTrace;
                dto.ErrorEx = ex.Message;
                dto.ErrorMsj = "Error al insertar en TablaVarios";
            }
            ObjCn.Close();
            return dto;
        }
        public ClassResultV Usp_TablaVarios_Update(DtoB dtoBase)
        {
            DtoTablaVarios dto = (DtoTablaVarios)dtoBase;
            ClassResultV cr = new ClassResultV();
            SqlParameter[] pr = new SqlParameter[7];
            try
            {
                pr[0] = new SqlParameter("@IdTabVarios", SqlDbType.Int)
                {
                    Value = (dto.IdTabVarios)
                };
                pr[1] = new SqlParameter("@Valor", SqlDbType.VarChar, 200)
                {
                    Value = (V_ValidaPrNull(dto.Valor))
                };
                pr[2] = new SqlParameter("@Descripcion", SqlDbType.VarChar, 200)
                {
                    Value = (V_ValidaPrNull(dto.Descripcion))
                };
                pr[3] = new SqlParameter("TipoAtributo", SqlDbType.VarChar, 200)
                {
                    Value = (V_ValidaPrNull(dto.TipoAtributo))
                };
                pr[4] = new SqlParameter("@EntidadTabla", SqlDbType.VarChar, 200)
                {
                    Value = (V_ValidaPrNull(dto.EntidadTabla))
                };
                pr[5] = new SqlParameter("@UsuarioModificacionId", SqlDbType.Int)
                {
                    Value = (V_ValidaPrNull(dto.UsuarioModificacionId))
                };
                pr[6] = new SqlParameter("IB_Estado", SqlDbType.Bit)
                {
                    Value = (V_ValidaPrNull(dto.IB_Estado))
                };
                SqlHelper.ExecuteNonQuery(ObjCn, CommandType.StoredProcedure, "Usp_TablaVarios_Update", pr);
                if (!String.IsNullOrEmpty(Convert.ToString(pr[8].Value)))
                {
                    cr.ErrorMsj = Convert.ToString(pr[8].Value);
                    cr.LugarError = "Usp_TablaVarios_Update";
                }
            }
            catch (Exception ex)
            {
                cr.LugarError = ex.StackTrace;
                cr.ErrorEx = ex.Message;
                cr.ErrorMsj = "Error al actualizar los datos de TablaVarios";
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
