#Create the node stage
FROM node:latest as builder
#Set the working directory
WORKDIR /app
#Copy the file from the current directory to working directory
COPY . .
#Run npm install and build the application
RUN npm install && npm run ng build
#Create the nginx stage for serving the content
FROM nginx:alpine
#Set the working directory to nginx assets directory
WORKDIR /usr/share/nginx/html
#Remove the default nginx static files
RUN rm -rf ./*
#Copy the static content from builder stage
COPY --from=builder /app/dist/angularapp .
#Container run the nginx with global directive and Daemon off
ENTRYPOINT [ "nginx", "-g", "daemon off;" ]
