﻿using System;

namespace SmtpServer.Authentication
{
    public sealed class DelegatingUserAuthenticatorFactory : IUserAuthenticatorFactory
    {
        readonly Func<ISessionContext, IUserAuthenticator> _delegate;

        public DelegatingUserAuthenticatorFactory(Func<ISessionContext, IUserAuthenticator> @delegate)
        {
            _delegate = @delegate;
        }

        /// <summary>
        /// Creates an instance of the service for the given session context.
        /// </summary>
        /// <param name="context">The session context.</param>
        /// <returns>The service instance for the session context.</returns>
        public IUserAuthenticator CreateInstance(ISessionContext context)
        {
            return _delegate(context);
        }
    }
}