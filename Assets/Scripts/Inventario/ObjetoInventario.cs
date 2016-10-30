using UnityEngine;
using System;


public enum Tipo {Consumibles,equipo,objetosclave}


[ System.Serializable]


public class ObjetoInventario {

	public string Nombre;
	public Tipo Tipo;
	public string descripcion;
	public Sprite sprite;
	public GameObject Objeto;
	public string Extra1;
//
	public static void Asignar(ObjetoInventario de, ObjetoInventario a)
	{
	
		de.Nombre = a.Nombre;
		de.Tipo = a.Tipo;
		de.Objeto = a.Objeto;
		de.sprite = a.sprite;
		de.descripcion = a.descripcion;
		de.Extra1 = a.Extra1;
	
	}









}
