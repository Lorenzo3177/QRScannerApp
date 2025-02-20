# QRScannerApp - Программа для сканирования QR-кодов

## Описание проекта
**QRScannerApp** — это приложение для распознавания QR-кодов с изображений. Оно предоставляет простой и интуитивно понятный интерфейс для загрузки изображения с QR-кодом, его обработки и извлечения данных из QR-кода. Приложение использует **EmguCV**, обёртку для OpenCV, для обработки изображений и распознавания QR-кодов.

## Функции программы
- Загрузка изображений в формате **PNG**, **JPEG**, **BMP**.
- Сканирование QR-кодов с изображений.
- Отображение расшифрованного текста в текстовом поле.
- Возможность сохранить расшифрованный текст в файл.
- Поддержка двух языков интерфейса: **Русский** и **Английский**.

## Инструкция по запуску

### 1. Склонируйте репозиторий
Если ещё не сделали этого, клонируйте репозиторий на локальную машину:
```sh
git clone <URL_репозитори>
```
### 2. Откройте проект в Visual Studio Code
Откройте проект в Visual Studio Code или другой IDE, которая поддерживает работу с C#.
### 3. Установите зависимости
Убедитесь, что у вас установлен .NET SDK. Если нет, установите его с официального сайта: https://dotnet.microsoft.com/download.
В терминале выполните команду, чтобы установить все зависимости проекта:
```sh
dotnet restore
```
### 4. Сборка проекта
Соберите проект с помощью команды:
```sh
dotnet build
```
### 5. Запуск проекта
Для запуска проекта используйте команду:
```sh
dotnet run
```
Или соберите его в .exe-файл, используя команду:
```sh
dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true
```
После этого откройте папку publish, и запустите QRScannerApp.exe.
### 6. Логирование
Все ключевые операции логируются в файл app_log.txt, который поможет отследить ошибки и диагностировать проблему.

## История коммитов
