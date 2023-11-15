FROM node:18.18.0-alpine

WORKDIR /usr/src/app

COPY client/package*.json ./

RUN npm install

COPY client/ .

EXPOSE 3000

CMD ["npm","start"]