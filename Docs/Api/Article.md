## Create Articles
----

```api
POST /users/{userId}/create
```
### Create Article Request
```json

{
"title": "article title",
"authorId": "AuthorId",
"Subtitle": "article subtitle",
"content": "article content",
"cover_image": "imageUrl",
"tagIds": ["1", "2", "3"],
}
```
### Create Article Response
```json
{
"id":"uuid",
"title": "article title",
"authorId": "AuthorId",
"Subtitle": "article subtitle",
"content": "article content",
"created_at": "2023",
"updated_at": "2024",
"cover_image": "imageUrl",
"tagIds": ["health", "wealth", "work"],
"commentIds":["1","2","3"],
"reactionIds":["1","2","3"]
}
```