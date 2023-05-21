# Use an official Node.js runtime as a parent image
FROM node:14 AS build

# Set the working directory to /app
WORKDIR /app

# Copy the package.json and package-lock.json files to the working directory
COPY package*.json ./

# Install app dependencies
RUN npm install

# Copy the rest of the app files to the working directory
COPY . .

# Build the app
RUN npm run build

# Expose port 4200
EXPOSE 4200

# Start the app
CMD ["npm", "start"]