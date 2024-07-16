Задание
![image](https://github.com/user-attachments/assets/67b70915-48d6-4280-88aa-6b2b23d8a848)

Отношения. ER-диаграмма
![image](https://github.com/user-attachments/assets/a4e23d2a-c862-452f-a4ba-dfa8e11fa643)

Демонстрация работы программы
![Снимок экрана 2024-07-16 122232](https://github.com/user-attachments/assets/1b462931-4775-4ed4-8c00-9633e2a9c22b)

Создание базы данных и отношений

+------------------------------+

CREATE DATABASE practice2024

    WITH
    
    OWNER = postgres
    
    ENCODING = 'UTF8'
    
    LC_COLLATE = 'Russian_Russia.1251'
    
    LC_CTYPE = 'Russian_Russia.1251'
    
    LOCALE_PROVIDER = 'libc'
    
    TABLESPACE = pg_default
    
    CONNECTION LIMIT = -1
    
    IS_TEMPLATE = False;
    

CREATE TABLE IF NOT EXISTS public."ROLE"

(

    id_role integer NOT NULL,
    
    name_role text COLLATE pg_catalog."default" NOT NULL,
    
    CONSTRAINT "ROLE_pkey" PRIMARY KEY (id_role)
    
)



CREATE TABLE IF NOT EXISTS public."USER"

(

    id_user integer NOT NULL,
    
    name_user text COLLATE pg_catalog."default" NOT NULL,
    
    CONSTRAINT "USER_pkey" PRIMARY KEY (id_user)
    
)



CREATE TABLE IF NOT EXISTS public."USER_ROLE"

(

    id_user integer NOT NULL,
    
    id_role integer NOT NULL,
    
    CONSTRAINT id_role FOREIGN KEY (id_role)
    
        REFERENCES public."ROLE" (id_role) MATCH SIMPLE
        
        ON UPDATE NO ACTION
        
        ON DELETE NO ACTION,
        
    CONSTRAINT id_user FOREIGN KEY (id_user)
    
        REFERENCES public."USER" (id_user) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)
