# ベースイメージの設定
FROM debian:buster-slim

# 必要なツールのインストール
RUN apt-get update && apt-get install -y wget gnupg lsb-release

# PostgreSQLの公式リポジトリを追加
RUN echo "deb http://apt.postgresql.org/pub/repos/apt/ $(lsb_release -cs)-pgdg main" > /etc/apt/sources.list.d/pgdg.list
RUN wget --quiet -O - https://www.postgresql.org/media/keys/ACCC4CF8.asc | apt-key add -

# PostgreSQLのインストール
RUN apt-get update && apt-get install -y postgresql postgresql-contrib

# データベースのセットアップ
USER postgres

RUN /etc/init.d/postgresql start && \
    psql --command "CREATE USER myuser WITH SUPERUSER PASSWORD 'mypassword';" && \
    createdb -O myuser mydb

# 初期データのロード（オプション。必要に応じてコメントアウトを外して使用）
# COPY initial_data.sql /tmp/
# RUN /etc/init.d/postgresql start && psql mydb < /tmp/initial_data.sql

USER root
