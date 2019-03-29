
using System;
using System.IO;
using Trilhas.JsonFormat;
using UnityEngine;

namespace Trilhas.Utilities
{
	public static class Tools
	{

		public static LojaItem MochilaToLoja(Mochila mochilaItem)
		{

			LojaItem lojaItem = new LojaItem()
			{
				bonus = mochilaItem.bonus,
                codigo = mochilaItem.codigo,
                descricao = mochilaItem.descricao,
                eixo = mochilaItem.eixo,
                imagem = mochilaItem.imagem,
                limite = mochilaItem.limite,
                nome = mochilaItem.nome,
				tipo = mochilaItem.tipo
			};
			return lojaItem;
		}


		public static Mochila LojaToMochila(LojaItem lojaItem)
		{
			var mochilaItem = new Mochila
			{
				bonus = lojaItem.bonus,
				codigo = lojaItem.codigo,
				descricao = lojaItem.descricao,
				eixo = lojaItem.eixo,
				estausando = false,
				imagem = lojaItem.imagem,
				limite = lojaItem.limite,
				nome = lojaItem.nome,
				tipo = lojaItem.tipo
			};
			return mochilaItem;
		}

		public static Sprite LoadImageFile(String filename, ItemTipo tipo,EixoNome eixo)
        {
			Sprite sprite = null;
			try
			{
				string eixoString = Enum.GetName(typeof(EixoNome), eixo);
				string tipoString = Enum.GetName(typeof(ItemTipo), tipo);
				if (filename == null)
				{
					filename = "_";	
				}
				var filePath = Path.Combine("Sprites", tipoString, eixoString, filename);
				Debug.Log(filePath);
				sprite = Resources.Load<Sprite>(filePath);
			}catch(Exception e)
			{
				Debug.LogWarning(e);
			}
			return sprite;

        }
	}
}