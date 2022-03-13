<h1 align="center"> Global Rating System </h1>

<h3 align="center">
  Микросервис для проекта Trustartup.
</h3>

## Содержание

-   [Описание](#описание)
-   [Технологии](#технологии)
-   [Использование](#использование)

## Описание

Обновляет глобальные рейтинги у стартапов.

~~Просто бегает по табличке и обновляет рейтинги, запрашивая их у Rating Calculation System~~

## Технологии

-   ASP.NET (C#)
-   Docker

## Использование

Микросервис компилируется и запускается в докере.

### Docker

-   [Docker](https://www.docker.com/get-docker)

Сначала постройте образ:

```bash
docker-compose build
```

Запустите микросервис:

```bash
docker-compose up -d
```
