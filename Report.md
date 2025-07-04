# Звіт про проходження практики

**Тема:** Розробка REST API для системи керування абонементами у спортзалі.

## 1. Мета та індивідуальне завдання

Метою практики було закріплення знань з архітектури сучасних веб-застосунків на платформі .NET та набуття практичного досвіду у створенні REST API з використанням багаторівневої архітектури (DAL, BLL, API).

## 2. Отримані результати

У процесі проходження практики було розроблено веб-застосунок типу REST API.

Система побудована на основі тришарової архітектури з чітким розподілом на шари: Data Access Layer (DAL), Business Logic Layer (BLL) та Application Programming Interface (API). Для зберігання даних про клієнтів, типи абонементів та придбані членства застосовано систему керування базами даних PostgreSQL.

Мапінг між сутностями бази даних та об'єктами передачі даних (DTO) реалізовано за допомогою бібліотеки AutoMapper.

Було реалізовано основний CRUD-функціонал (Create, Read, Update, Delete) для керування клієнтами. У процесі розробки дотримано SOLID принципів та активно використано механізм Dependency Injection, що забезпечило гнучкість та масштабованість коду. Також було впроваджено пагінацію та централізовану обробку помилок.

Результатом став повноцінний серверний застосунок, готовий до подальшої інтеграції з клієнтським веб-інтерфейсом.