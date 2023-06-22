using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace TextDecoderAPI.Controllers
{
    [ApiController]
    [Route("api/decoder")]
    public class DecoderController : ControllerBase
    {
        private static int totalRequests = 0; // Variável de contagem de requisições
        private static Dictionary<string, int> requestCountsByIp = new Dictionary<string, int>(); // Dicionário para armazenar contagem de requisições por IP

        public class DecodedTextDto
        {
            public string DecodedText { get; set; }
        }

        public class DecodedJsonDto
        {
            public string EncodedJson { get; set; }
        }

        [HttpGet]
        public ActionResult<DecodedTextDto> DecodeText([FromQuery] string encodedText)
        {
            try
            {
                string unescapedText = Regex.Unescape(encodedText);
                string decodedText = WebUtility.UrlDecode(unescapedText);

                // Obtém o endereço IP do cliente
                IPAddress clientIp = HttpContext.Connection.RemoteIpAddress;

                // Remove o prefixo "::ffff:" do mascaramento IPV6 se estiver presente
                if (clientIp.IsIPv4MappedToIPv6)
                {
                    clientIp = clientIp.MapToIPv4();
                }

                // Obtém o endereço IP como string
                string clientIpString = clientIp.ToString();

                // Incrementa a contagem de requisições para o IP atual
                if (requestCountsByIp.ContainsKey(clientIpString))
                {
                    requestCountsByIp[clientIpString]++;
                }
                else
                {
                    requestCountsByIp[clientIpString] = 1;
                }

                totalRequests++; // Incrementa a contagem total de requisições
                Console.WriteLine("--------------");
                Console.WriteLine("Nova Requisição");
                Console.WriteLine($"IP: {clientIpString}");
                Console.WriteLine($"Total do IP: {requestCountsByIp[clientIpString]:D2}");
                Console.WriteLine($"Total Geral: {totalRequests:D2}");
                Console.WriteLine("--------------");

                return Ok(new DecodedTextDto { DecodedText = decodedText });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
