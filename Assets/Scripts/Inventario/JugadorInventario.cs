using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class JugadorInventario : MonoBehaviour {

	public BDInventario DB;
	public ObjetoInventario[] Objetos = new ObjetoInventario[2];
    public int[] Cantidad = new int[2];
    public ObjetoInventario[] Equipo = new ObjetoInventario[2];
	//public PuntosInventario[] PuntoEquipo = new PuntosInventario[2];
//
	public void AgregarObjeto(int ID)
	{
		
		for (int i = 0; i < Objetos.Length; i++ )
		{
			

		   if (Objetos[i].Objeto == null)
			{
//				
				ObjetoInventario.Asignar(Objetos[i],DB.Database[ID]);
				Cantidad[i]++;
				return;
//
		} 
				else 
				{
	
					if (Objetos[i].Objeto == DB.Database[ID].Objeto)
					{
						Cantidad[i]++;
						return;
					}
				}

			}
		print ("No hay espacios libres");
		}



	public void Eliminar(int slot)
	{

		ObjetoInventario aux = new ObjetoInventario();

		if (Cantidad[slot] == 0 || Cantidad[slot] < 0)
		{

			ObjetoInventario.Asignar(Objetos[slot], aux);
		}
		else
		{

			Cantidad[slot]--;

			if (Cantidad[slot] == 0 || Cantidad[slot] < 0)
			{

				ObjetoInventario.Asignar(Objetos[slot], aux);
			}
		}
	}

	public void Usar(int slot)
	{
	
		if (Objetos[slot].Objeto != null) 
		{

			if (Objetos[slot].Tipo == Tipo.Consumibles)
			
			{
			
				print (Objetos[slot].Nombre + "fue usado");
			}



			else if (Objetos[slot].Tipo == Tipo.equipo)
			{

				if (Objetos[slot].Extra1 == "Helado 1") 
//				
				{

					if (Equipo[0].Objeto != null) 
					
					{
						
						int aux = 0;
						for (int i = 0; i < DB.Database.ToArray().Length; i++)
						
						{
						
							if (DB.Database[i].Objeto == Equipo[0].Objeto)
								aux = i;
						}

						ObjetoInventario.Asignar(Equipo[0], Objetos[slot]);
						Eliminar(slot);
						AgregarObjeto(aux);
					}
					else
					{
						ObjetoInventario.Asignar(Equipo[0], Objetos[slot]);
						Eliminar(slot);
					}

					//PuntoEquipo[0].Refrescar();
				}
				if (Objetos[slot].Extra1 == "Helado 2")
				{
				
					if (Equipo[1].Objeto != null) 

					{

						int aux = 0;
						for (int i = 0; i < DB.Database.ToArray().Length; i++)

						{

							if (DB.Database[i].Objeto == Equipo[1].Objeto)
								aux = i;
						}

						ObjetoInventario.Asignar(Equipo[1], Objetos[slot]);
						Eliminar(slot);
						AgregarObjeto(aux);
					}
					else
					{
						ObjetoInventario.Asignar(Equipo[1], Objetos[slot]);
						Eliminar(slot);
					}
					//PuntoEquipo[1].Refrescar();
				}

				
			}
			else if (Objetos[slot].Tipo == Tipo.objetosclave)
			{

				print ("No se puede usar el objeto");
			}
		
				
		}
	}


}
