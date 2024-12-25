using Blog.Application.Common.Authentication;
using Blog.Contracts.Authentication;
using Mapster;

namespace Blog.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config
                .NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(des => des.Token, src => src.Token)
                .Map(des => des, src => src.User);
        }
    }
}
