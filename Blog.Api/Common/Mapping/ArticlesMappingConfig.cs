using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Application.Articles.Commands;
using Blog.Contracts.Articles;
using Blog.Contracts.Articles.Blog.Contracts.Articles;
using Blog.Domain.Article;
using Blog.Domain.Tag.ValueObjects;
using Mapster;

namespace Blog.Api.Common.Mapping
{
    public class ArticlesMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config
                .NewConfig<(string userId, CreateArticleRequest request), CreateArticleCommand>()
                .Map(des => des.AuthorId, src => src.userId)
                .Map(des => des, src => src.request);
            config
                .NewConfig<Article, CreateArticleResponse>()
                .Map(dest => dest.Id, src => src.User.Value)
                .Map(dest => dest.Tags, src => src.Tags)
                .Map(dest => dest.CoverImage, src => src.CoverImageUrl)
                .Map(dest => dest.Tags, src => src.Tags);
            config.NewConfig<TagId, TagResponse>().Map(dest => dest.Id, src => src.Value);
            config.NewConfig<TagResponse, TagId>().Map(dest => dest.Value, src => src.Id);
        }
    }
}
