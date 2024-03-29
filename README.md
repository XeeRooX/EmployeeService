# Employee Service
Этот проект представляет собой сервис для ведения информации о сотрудниках. Он был разаработан на основе задания, которое описано ниже.

Необходимо написать сервис, позволяющий создавать и редактировать сотрудников организации. Сотрудники должны иметь должность, на основе которой рассчитывается их заработная плата. Помимо CRUD-запросов должен присутствовать пагинированный запрос, включающий поле для сортировки, поле для фильтрации (по ФИО-сотрудника или должности).

### Использованные технологии и библиотеки
.NET 6.0, ASP.NET Core 6.0, EFCore 6.0, PostreSQL, FluentValidation 11.8.0, React 18.2.0, Node.js 18.18, axios 1.6.1, Bootstrap 5.3.2, Docker, Docker Compose
## Запуск
1. Клонировать текущий репозиторий
2. Перейти в папку с проектом
3. Выполнить команду ниже:
```
    docker compose up
```
Чтобы зайти в клиент нужно перейти по адресу:
```
http://localhost:3000
```

![image](https://github.com/XeeRooX/EmployeeService/assets/91987012/2584e8d3-1579-4382-8bc1-71b380d0cb87)

Чтобы зайти в Swagger UI можно перейти по адресу:
```
http://localhost:5000/swagger
```

![image](https://github.com/XeeRooX/EmployeeService/assets/91987012/5c9c4f0f-7dc5-4fd4-840a-3b277bc8f29f)

## Конфигурация
Вся основная конфигурация хранится в переменных окружения, которые можно назначить в файле docker-compose.yml в блоке environment. Все переменные, описанные в этом блоке, стандартные кроме нескольких:
- ConnectionStrings__DefaultConnection - хранит в себе значение строки подключения к базе данных
- ClientHostname - хранит в себе хост клента. По умолчанию localhost:3000

Также для клиента можно назначить путь до API. Для этого нужно в файле, который расположен по пути client/src/config.json, задать значение для переменной API_URL. По умолчанию API_URL = "http://localhost:5000/api/v1/"
