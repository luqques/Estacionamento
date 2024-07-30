FROM node:18-alpine

WORKDIR /estacionamento-app/

COPY public/ /estacionamento-app/public
COPY src/ /estacionamento-app/src
COPY package.json /estacionamento-app/

RUN npm install
CMD ["npm", "start"]