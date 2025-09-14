"use client";

import Image from "next/image";
import { useState } from "react";

export default function Home() {
  const [text, setText] = useState("");
  const [qrUrl, setQrUrl] = useState<string | null>(null);

  const handleGenerate = async () => {
    if (!text.trim()) return;
    const apiUrl = `http://localhost:5096/api/qrcode?text=${encodeURIComponent(
      text
    )}`;
    setQrUrl(apiUrl);
  };

  return (
    <div className="min-h-screen flex flex-col items-center justify-center">
      <h1 className="text-3xl mb-4">QR Code Generator</h1>
      <input
        className="border p-2 mb-4"
        type="text"
        value={text}
        onChange={(e) => setText(e.target.value)}
        placeholder="Enter text"
      />
      <button
        className="bg-blue-500 text-white px-4 py-2"
        onClick={handleGenerate}
      >
        Generate QR Code
      </button>

      {qrUrl && (
        <div className="mt-6">
          <img src={qrUrl} alt="QR Code" />
        </div>
      )}
    </div>
  );
}
