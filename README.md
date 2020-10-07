# xt_net_web_Final_Project
xt_net_web Final Project - Food Journal

#### Project description

1. Usage scenarios:
- user registration, user profile editing;
- view existing products, filter by category using the side menu (user);
- adding products to the Dish diet list to calculate the number of calories consumed, selectively removing products from the list, clearing the list (user);
- graphical display of products from the list with the number of calories consumed for each (user);
- search by name (user and admin);
- add new products, edit and delete (admin);
- view registered users (admin);
- graphical display of database occupancy for each category (admin).
2. Used technology ASP.NET Web Pages.
3. Pages contain user interface elements generated and grouped using partial pages and layout templates.
4. Used client-side JavaScript to validate input.
5. Desirable AJAX, responsive layout - is not used.
6. Forms-based authentication and user role support are implemented, without using Membership and the standard membership database.
7. Implemented layered architecture of the project.
8. Implemented own database dbo.FoodJournal with relationships between tables normalized to the third normal form. A custom DAL was created as the access level on ADO.NET, without using the Entity Framework and other O/RM.
9. Implemented logging of exceptional situations (log4net) and error handling with redirection to Error page in case of a fatal error when the application is running.

#### Описание проекта

1. Сценарии использования:
- регистрация пользователей, редактирование пользовательского профиля;
- просмотр продуктов в базе, фильтрация по категориям с помощью бокового меню (пользователь);
- добавление продуктов в список рациона Dish для подсчета количества потребленных калорий, выборочное удаление продуктов из списка, очистка списка (пользователь);
- графическое отображение продуктов из списка с указанием количества потребленных калорий по каждому (пользователь);
- поиск по наименованию (пользователь и администратор);
- добавление новых продуктов, редактирование и удаление (администратор);
- просмотр зарегистрированных пользователей (администратор);
- графическое отображение заполненности базы по каждой категории (администратор).
2. Использована технология ASP.NET Web Pages. 
3. Страницы содержат элементы пользовательского интерфейса, сгенерированные и сгруппированные с помощью частичных страниц (partial pages), шаблонов (layout). 
4. Использован клиентский JavaScript для валидации ввода.
5. Желательно наличие AJAX, responsive вёрстки – не используется.
6. Реализована аутентификация на основе Forms, поддержка ролей пользователей, без использования Membership и стандартной базы данных membership. 
7. Реализована многоуровневая архитектура проекта. 
8. Реализована собственная база данных dbo.FoodJournal со связями между таблицами, нормализованными до третьей нормальной формы. В качестве уровня доступа создан собственный DAL на ADO.NET, без использования Entity Framework и прочих O/RM.
9. Реализовано протоколирование исключительных ситуаций (log4net) и обработка ошибок c переадресацией на Error page в случае фатальной ошибки при работе приложения.
