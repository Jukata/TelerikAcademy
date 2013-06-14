function isValidInputNumber(number) {
    if (!isNaN(number) && isFinite(number)) {
        return true;
    }
    else {
        return false;
    }
}