let Twitter = require("twitter");

module.exports = function(context, req) {
  context.log("Azure Functions Twitter Demo");

  var client = new Twitter({
    consumer_key: process.env["TwitterAppKey"],
    consumer_secret: process.env["TwitterAppSecret"],
    access_token_key: process.env["TwitterAccessToken"],
    access_token_secret: process.env["TwitterAccessTokenSecret"]
  });

  let messageMap = {
    arrived: "Arrived at #ServerlessConf NYC. Trying out this cool #AzureFunctions demo!",
    joinme: "You should join me at the Microsoft booth at #Serverlessconf NYC!",
    azurefunctions: "Azure Functions is awesome!"
  };

  let messageType = context.bindingData.messageType;
  let statusMessage = messageMap[messageType];

  if (statusMessage) {
    client.post("statuses/update", { status: statusMessage },
     function(error,tweet,  response) {
      if (error) throw error;
      context.log(tweet); // Tweet body.
      context.log(response); // Raw response object.
      context.res = {
        status: 200,
        body: "Tweet sent"
      };
      context.done();
    });
  } else {
    context.res = {
      status: 400,
      body: "Invalid request. Messing message type"
    };
    context.done();
  }
};