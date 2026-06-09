using System;

namespace PureGreeter;

public class HourOutOfRangeException() : ArgumentException("Hour must be between 0 and 23");