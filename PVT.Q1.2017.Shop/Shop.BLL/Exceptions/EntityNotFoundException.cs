namespace Shop.BLL.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using System.Security.Permissions;
    using Infrastructure.Models;

    /// <summary>
    /// The entity not found exception
    /// </summary>
    [Serializable]
    public class EntityNotFoundException<T> : Exception where T : BaseEntity, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotFoundException{T}"/> class.
        /// </summary>
        public EntityNotFoundException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotFoundException{T}"/> class.
        /// </summary>
        /// <param name="entity">
        /// The entity which is not found.
        /// </param>
        public EntityNotFoundException(T entity)
        {
            Entity = entity;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotFoundException{T}"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public EntityNotFoundException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotFoundException{T}"/> class.
        /// </summary>
        /// <param name="entity">
        /// The entity which is not found.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public EntityNotFoundException(T entity, string message) : base(message)
        {
            Entity = entity;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotFoundException{T}"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="inner">
        /// The inner exception.
        /// </param>
        public EntityNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotFoundException{T}"/> class.
        /// </summary>
        /// <param name="entity">
        /// The entity which is not found.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="inner">
        /// The inner exception.
        /// </param>
        public EntityNotFoundException(T entity, string message, Exception inner) : base(message, inner)
        {
            Entity = entity;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotFoundException{T}"/> class.
        /// </summary>
        /// <param name="info">
        /// The <see cref="SerializationInfo" /> that holds the serialized object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        /// The <see cref="StreamingContext" /> that contains contextual information about the source or destination.
        /// </param>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected EntityNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            string entityId = info.GetString("EntityId");
            if (!string.IsNullOrWhiteSpace(entityId))
            {
                Entity = new T { Id = Convert.ToInt32(entityId) };
            }
        }

        /// <summary>
        /// Gets or sets the entity which is not found.
        /// </summary>
        public T Entity { get; protected set; }

        /// <summary>
        /// Fills the <see cref="SerializationInfo"/> with information about exception
        /// </summary>
        /// <param name="info">
        /// The <see cref="SerializationInfo" /> that holds the serialized object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        /// The <see cref="StreamingContext" /> that contains contextual information about the source or destination.
        /// </param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info != null && Entity != null)
            {
                info.AddValue("EntityId", Entity.Id);
            }

            base.GetObjectData(info, context);
        }
    }
}