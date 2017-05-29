namespace Shop.BLL.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class UserValidationException : Exception, ISerializable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserValidationException"/> class.
        /// </summary>
        public UserValidationException() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserValidationException"/> class.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="property"></param>
        public UserValidationException(string message, string property) : base(message)
        {
            UserProperty = property;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserValidationException"/> class.
        /// </summary>
        public UserValidationException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserValidationException"/> class.
        /// </summary>
        public UserValidationException(string message, Exception inner) : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserValidationException"/> class.
        /// </summary>
        public UserValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        /// <summary>
        /// User property with exception
        /// </summary>
        public string UserProperty { get; set; }
    }
}
