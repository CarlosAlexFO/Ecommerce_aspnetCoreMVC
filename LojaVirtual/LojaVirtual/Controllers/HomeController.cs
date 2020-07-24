﻿
using LojaVirtual.Libraries.Email;
using LojaVirtual.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Contato()
        {
            return View();
        }

        public IActionResult ContatoAcao()
        {
          
            {
                try
                {
                    Contato contato = new Contato();
                    contato.Nome = HttpContext.Request.Form["nome"];
                    contato.Email = HttpContext.Request.Form["email"];
                    contato.Texto = HttpContext.Request.Form["texto"];

                    var listaMensagens = new List<ValidationResult>();
                    var contexto = new ValidationContext(contato);
                    bool isValid =  Validator.TryValidateObject(contato, contexto, listaMensagens, true);

                    if (isValid)
                    {
                        ContatoEmail.EnviarContatoPorEmail(contato);

                        ViewData["MSG_S"] = "Mensagem de Contato enviada com Sucesso!";
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (var texto in listaMensagens)
                        {
                            sb.Append(texto.ErrorMessage);
                        }
                        ViewData["MSG_E"] = sb.ToString();
                    }
            

                }
                catch (Exception e)
                {

                    ViewData["MSG_E"] = "Ooops! Tivemos um erro, tente novamente mais tarde!";

                    //TODO - Implementar Log
                }

            }
           
            return View("Contato");
        }





        public IActionResult Login()
        {
            return View();
        }
        public IActionResult CadastroCliente()
        {
            return View();
        }
        public IActionResult CarrinhoCompras()
        {
            return View();
        }
    }
}