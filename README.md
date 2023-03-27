# EmployeesAPI


Стек технологий
Вот технологии, которые мы будем использовать для создания нашего приложения:


• C# — современный объектно-ориентированный и типобезопасный язык программирования. 

• Visual Studio 2022 (IDE) — это многофункциональная программа, которая 
поддерживает многие аспекты разработки программного обеспечения. 

• dotNET — модульная платформа для разработки программного обеспечения 
с открытым исходным кодом. 

• API – Application Programming Interface, что значит программный 
интерфейс приложения.Описание способов взаимодействия 
одной компьютерной программы с другими. 

• REST — архитектурный стиль взаимодействия компонентов 
распределённого приложения в сети. 

• Swagger — это язык описания интерфейса для описания RESTful API, 
выраженных с помощью JSON. Swagger используется вместе с набором 
программных средств с открытым исходным кодом для проектирования, 
создания, документирования и использования веб-служб RESTful.

• SQLite — это внутрипроцессная библиотека, которая реализует автономный, 
бессерверный, не требующий настройки транзакционный механизм базы данных SQL. 

• Entity Framework — объектно-ориентированная технология доступа к данным, 
является object-relational mapping решением для .NET Framework от Microsoft. 
Предоставляет возможность взаимодействия с объектами как посредством LINQ 
в виде LINQ to Entities, так и с использованием Entity SQL. 

• JSON — это популярный формат текстовых данных, который используется для обмена 
данными в современных веб - и мобильных приложениях. 



Детали архитектуры
Этот проект имеет 3 уровня:


1. Core: 
Делится на два подуровня:

1.1 API: ASP.NET (Enterprise-логика может использоваться в разных приложениях)
2.2 Application: Бизнес логика приложения.

2. Infrastructure: База данных полностью настроена на этом уровне.
3. 
4. Presentation: web API with ASP.NET Core.


Уровни Infrastructure и Presentation:  зависят от Core.
Core не содержит прямых зависимостей.



Обзор
В этом руководстве создается следующий API-интерфейс:
Описание методов API:


class EmployeeController:


Получаем данные всех сотрудников.
GET api/v1/employees


Получаем данные сотрудника по его логину.
GET api/v1/employees/{name}


Добавляем нового сотрудника.
POST api/v1/employees


Обновляем данные сотрудника.
PUT api/v1/employees


Удаляем сотрудника.
DELETE api/v1/employees



Использование
Пример использования этого API:


Проверка в Postman

Пример запроса:
https://localhost:32770/api/v1/employees

Пример ответа:
{
    "employees": []
}
