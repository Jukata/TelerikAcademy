function escapeTags(message) {
    message += "";
    var ltIndex = message.indexOf("<");
    while (ltIndex != -1) {
        message = message.replace("<", "&lt;");
        ltIndex = message.indexOf("<");
    }
    var gtIndex = message.indexOf(">");
    while (gtIndex != -1) {
        message = message.replace(">", "&gt;");
        gtIndex = message.indexOf("<");
    }

    return message;
}