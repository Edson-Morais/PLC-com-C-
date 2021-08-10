using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyModbus;

namespace PLC_COM_CS
{
    class Conexao
    {
        private ModbusClient clp = new ModbusClient(); //variavel conexão com CLP
        private int[] registros; // variavel de retorno dos registros
        private bool[] coils; // variavel de retorno das bobinas
        public bool con; // variavel de verificação se conectado ou não



        // Construtor
        public Conexao()
        {
            
        }

        // Metodo Conectar
        private int[] lerRegistros( string ip,int inicio, int quantidade)
        {
            try
            {
                clp.Connect(ip, 502);
                registros = clp.ReadHoldingRegisters(inicio, quantidade);
                con = true;
            }
            catch
            {
                con = false;
            }
            return registros;
        }
        private bool[] lerCoils(string ip, int inicio, int quantidade)
        {
            try
            {
                clp.Connect(ip, 502);
                coils = clp.ReadCoils(inicio, quantidade);
                con = true;
            }
            catch
            {
                con = false;
            }
            return coils;
        }

    }
}
