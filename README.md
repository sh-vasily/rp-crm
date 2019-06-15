Задание :

Компания Ромашка и Партнёры (РиП) решила перевести свою базу клиентов в электронный вид. Клиенты РиП – это другие компании, с каждой из которых заключается договор. У компаний-клиентов есть пользователи, которых РиП обслуживает. Необходимо разработать настольное WPF** -приложение**, которое поможет компании достичь поставленной цели.

Технические требования к системе:

Приложение: WPF/MVVM
База данных: MSSQL
ORM: EntityFramework
Есть пользователь (User) со свойствами Id, Name, Login, Password

Есть компания (Company) со свойствами Id, Name, ContractStatus

ContractStatus - статус договора на услуги с компанией, принимает значения: Ещё не заключен, Заключен, Расторгнут

В компании может быть несколько пользователей

Пользователей без компании не существует

Требования к функционалу : Приложение должно позволять:

Создавать/Редактировать/Удалять компании
Создавать/Редактировать/Удалять пользователей
Отображать списки компаний и пользователей компании
Результат : Ссылка на репозиторий github, где лежит проект и скрипты для создания БД
