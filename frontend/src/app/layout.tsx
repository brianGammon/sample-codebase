import type { Metadata } from "next";
import { GeistSans } from "geist/font/sans";
import "./globals.css";

export const metadata: Metadata = {
  title: "Project Tracker",
  description: "Track and manage your projects",
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body className={GeistSans.className}>
        <div className="min-h-screen bg-background">
          <header className="sticky top-0 z-50 w-full border-b bg-background/95 backdrop-blur supports-[backdrop-filter]:bg-background/60">
            <div className="container flex h-14 items-center mx-auto px-4">
              <div className="flex gap-2 items-center mr-4">
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  width="24"
                  height="24"
                  viewBox="0 0 24 24"
                  fill="none"
                  stroke="currentColor"
                  strokeWidth="2"
                  strokeLinecap="round"
                  strokeLinejoin="round"
                  className="text-foreground"
                >
                  <path d="M2 9a3 3 0 0 1 0-6h20a3 3 0 0 1 0 6Z"></path>
                  <path d="M13 18a3 3 0 0 1 0-6h9a3 3 0 0 1 0 6Z"></path>
                  <path d="M2 21a3 3 0 0 1 0-6h6a3 3 0 0 1 0 6Z"></path>
                </svg>
                <span className="font-bold">Project Tracker</span>
              </div>
            </div>
          </header>
          {children}
        </div>
      </body>
    </html>
  );
}
