namespace EmployeeLeaveManagementSystemAPI.Responses
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }

        public string Message { get; set; } = string.Empty;

        public T? Data { get; set; }

        public int StatusCode { get; set; }

        public DateTime Timestamp { get; set; }
            = DateTime.UtcNow;
    }
}

// creates a standard response format for all APIs.