# Технічне завдання: REST API для спортзалу "GymMembership"

## 1. Мета та опис проекту

Розробити серверний додаток (REST API) для керування клієнтами та їх абонементами у фітнес-центрі. Система має надавати програмний інтерфейс для майбутньої інтеграції з клієнтськими додатками (веб-сайт, мобільний додаток).

**Основні технології:**
- Платформа: .NET 8
- Архітектура: Тришарова (DAL, BLL, API)
- База даних: PostgreSQL
- ORM: Entity Framework Core (Code First)

## 2. Беклог продукту у вигляді User Stories

### 2.1. Керування клієнтами:
- **Як** адміністратор, **я хочу** додати нового клієнта в систему, **щоб** вести облік відвідувачів.
- **Як** адміністратор, **я хочу** бачити список усіх клієнтів, **щоб** мати загальне уявлення про клієнтську базу.
- **Як** адміністратор, **я хочу** знаходити клієнта за його ID, **щоб** швидко переглянути його дані.
- **Як** адміністратор, **я хочу** редагувати інформацію про клієнта (наприклад, номер телефону), **щоб** підтримувати дані актуальними.
- **Як** адміністратор, **я хочу** видалити клієнта з системи, **щоб** прибрати неактуальні або помилкові записи.

### 2.2. Керування абонементами (майбутній функціонал):
- **Як** адміністратор, **я хочу** продати клієнту абонемент, **щоб** фіксувати продажі та активувати членство.
- **Як** адміністратор, **я хочу** бачити, які абонементи активні у конкретного клієнта, **щоб** контролювати термін їх дії.

## 3. Опис MVP (Minimum Viable Product)

В рамках поточної версії було реалізовано MVP, сфокусований на базовому керуванні клієнтською базою.

**Функціонал, що входить до MVP:**
- Повноцінне CRUD-керування сутністю "Клієнт" (Create, Read, Update, Delete).
- Пагінація для списку клієнтів.
- Валідація вхідних даних при створенні/оновленні.
- Централізована обробка помилок.

**Фуціонал, що НЕ входить до MVP:**
- Керування абонементами.
- Аутентифікація та авторизація.
- Розширена фільтрація та сортування.