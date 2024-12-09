import React from "react";
import Posts from "../src/components/Posts"; // Adjust the path if the Posts component is in a different folder

const App: React.FC = () => {
    return (
        <div>
            <h1>My Blog</h1>
            <Posts />
        </div>
    );
};

export default App;
