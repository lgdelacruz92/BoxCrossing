public class NetworkingError {
    public readonly int ERROR;
    public readonly string MESSAGE;

    public NetworkingError(int _error, string _message) {
        ERROR = _error;
        MESSAGE = _message;
    }
}

public class NetworkingErrorCode {
    public static readonly int NETWORK_ERROR = 0;
    public static readonly int NAME_IS_EMPTY = 0;
}