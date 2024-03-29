﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Calculadora.Data.Converters;
using Calculadora.Data.VO;
using Calculadora.Model;
using Calculadora.Repository;
using Calculadora.Repository.Generic;
using Calculadora.Security.Configuration;

namespace Calculadora.Business.Implementattions
{
    public class LoginBusinessImpl : ILoginBusiness
    {

        private IUserRepository _repository;
        private SigningConfigurations _signingConfigurations;
        private TokenConfiguration _tokenConfiguration;

        public LoginBusinessImpl(IUserRepository repository, SigningConfigurations signingConfigurations,TokenConfiguration tokenConfiguration)
        {
            _repository= repository;
            _signingConfigurations = signingConfigurations;
            _tokenConfiguration = tokenConfiguration;
        }

        public object FindByLogin(UserVO user)
        {
            bool credentialsIsValid = false;
            if(user !=null && !string.IsNullOrWhiteSpace(user.Login))
            {
                var BaseUser = _repository.FindByLogin(user.Login);
                credentialsIsValid = (BaseUser != null && user.Login == BaseUser.Login && user.Accesskey == BaseUser.AccessKey);
            }
            if (credentialsIsValid)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(user.Login,"Login"),
                    new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName,user.Login)
                    }
                    );
                DateTime createDate = DateTime.Now;
                DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfiguration.Seconds);

                var handler = new JwtSecurityTokenHandler();
                string token = CreateToken(identity, createDate, expirationDate, handler);
                return SuccessObject(createDate, expirationDate, token);
            }
            else { return ExceptionObject(); }
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                Issuer = _tokenConfiguration.Issuer,
                Audience = _tokenConfiguration.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
            }) ;

            var token = handler.WriteToken(securityToken);
            return token;
        }
        private object ExceptionObject()
        {
            return new
            {
                autenticated = false,
                message = "Failed Autheticate"
            };
        }

        private object SuccessObject(DateTime createDate,DateTime expirationDate,string token)
        {
            return new
            {
                autenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                message = "OK"
            };
        }
    }
}
