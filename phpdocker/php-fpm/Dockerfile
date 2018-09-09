FROM phpdockerio/php72-fpm:latest

WORKDIR /app/

# Install selected extensions and other stuff
RUN apt-get update \
    && apt-get -y --no-install-recommends install  php7.2-mysql \
    && apt-get clean; rm -rf /var/lib/apt/lists/* /tmp/* /var/tmp/* /usr/share/doc/*

COPY docker-entrypoint.sh /
COPY etc/bootstrap.d  /entrypoint.d
ONBUILD COPY etc/bootstrap.d  /entrypoint.d

RUN chmod 777 /docker-entrypoint.sh

ENTRYPOINT ["/docker-entrypoint.sh"]
CMD ["--no-daemonize"]