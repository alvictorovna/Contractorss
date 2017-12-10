using System;
using Contractorss.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contractorss
{
    public class DbInitializer
    {
        public static void Initialize(ContractorsContext db)
        {
            db.Database.EnsureCreated();

             //Проверка занесены ли виды топлива
            if (db.Contractors.Any())
           {
                return;   // База данных инициализирована
            }

            int contractor_number = 35;
            int manufacturer_number = 35;
            int build_number = 300;
            string contractType;
            string nameMaterial;
            string manufacttType;

            Random randObj = new Random(1);

            //Заполнение таблицы емкостей
            string[] tank_voc = { "IvanovoStroi", "OAO Ведро", "БакFK", "VETERSTROI", "StroiKA" };//словарь названий емкостей
            int count_tank_voc = tank_voc.GetLength(0);
            for (int tankID = 1; tankID <= contractor_number; tankID++)
            {
                contractType = tank_voc[randObj.Next(count_tank_voc)] + tankID.ToString();
                db.Contractors.Add(new Contractor { NameCompany = contractType});
            }
            //сохранение изменений в базу данных, связанную с объектом контекста
            db.SaveChanges();

            //Заполнение таблицы видов топлива
            string[] fuel_voc = { "GlinaMes", "BenzoLit", "OAO Shera", "OOO СтройРемонт"};
            int count_fuel_voc = fuel_voc.GetLength(0);
            for (int fuelID = 1; fuelID <= manufacturer_number; fuelID++)
            {
                manufacttType = fuel_voc[randObj.Next(count_fuel_voc)] + fuelID.ToString();
                db.Manufacturers.Add(new Manufacturer { ManufacturerName = manufacttType});
            }
            //сохранение изменений в базу данных, связанную с объектом контекста
            db.SaveChanges();

            //Заполнение таблицы операций
            string[] name_Material = { "Kirpich", "Benzin", "Grunt", "Kraska" };
            int count_building_voc = name_Material.GetLength(0);
            for (int operationID = 1; operationID <= build_number; operationID++)
            {
                int tankID = randObj.Next(1, contractor_number - 1);
                int fuelID = randObj.Next(1, manufacturer_number - 1);
                int inc_exp = randObj.Next(200);
                nameMaterial = name_Material[randObj.Next(count_building_voc)];
                db.BuildingMaterials.Add(new BuildingMaterial { ContractorId = tankID, ManufacturerId = fuelID, NameMaterial = nameMaterial, VolumePurchaseQuantity= inc_exp });
            }

            //сохранение изменений в базу данных, связанную с объектом контекста
            db.SaveChanges();
        }

    }
}
