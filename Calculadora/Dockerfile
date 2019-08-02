FROM mysql:8.0.17
EXPOSE 3306
COPY ./Calculadora/Calculadora/db/migrations /home/database
COPY ./Calculadora/Calculadora/db/dataset /home/database
COPY ./Calculadora/Calculadora/ci/init_database.sh /docker-entrypoint-initdb.d/init_database.sh
