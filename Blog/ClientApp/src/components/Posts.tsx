import React, { useEffect, useState } from "react";

interface Post {
    id: string;
    categoryId: string | null;
    categoryName: string | null;
    title: string;
    body: string | null;
    description: string;
    publishDate: string;
    modifiedDate: string;
    isDelete: boolean | null;
}

const Posts: React.FC = () => {
    const [posts, setPosts] = useState<Post[]>([]);
    const [loading, setLoading] = useState<boolean>(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        const fetchPosts = async () => {
            try {
                const response = await fetch("https://localhost:5000/Post/GetPosts");
                if (!response.ok) {
                    throw new Error("Failed to fetch posts");
                }
                const data: Post[] = await response.json();
                setPosts(data);
            } catch (err) {
                setError(err instanceof Error ? err.message : "Unknown error");
            } finally {
                setLoading(false);
            }
        };

        fetchPosts();
    }, []);

    if (loading) {
        return <div>Loading...</div>;
    }

    if (error) {
        return <div>Error: {error}</div>;
    }

    return (
        <div>
            <h1>Posts</h1>
            <table>
                <thead>
                <tr>
                    <th>Title</th>
                    <th>Description</th>
                    <th>Publish Date</th>
                    <th>Modified Date</th>
                </tr>
                </thead>
                <tbody>
                {posts.map((post) => (
                    <tr key={post.id}>
                        <td>{post.title}</td>
                        <td>{post.description}</td>
                        <td>{new Date(post.publishDate).toLocaleString()}</td>
                        <td>{new Date(post.modifiedDate).toLocaleString()}</td>
                    </tr>
                ))}
                </tbody>
            </table>
        </div>
    );
};

export default Posts;
