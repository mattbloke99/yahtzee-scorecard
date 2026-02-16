#!/bin/sh
set -e

# Replace PORT placeholder in nginx config
sed -i "s/listen 8080;/listen ${PORT};/g" /etc/nginx/nginx.conf

# Start nginx
exec nginx -g 'daemon off;'
