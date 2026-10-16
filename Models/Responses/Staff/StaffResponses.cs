using System;

namespace AspSakilaBackEnd.Models.Responses
{
    public class StaffResponse
    {
        public byte StaffId { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        // クライアント側で使いやすいフルネームの便利プロパティ
        public string FullName => $"{FirstName} {LastName}";

        public ushort AddressId { get; set; }

        // 必要に応じて住所の文字列を含める（Address ナビゲーションプロパティから取得）
        public string? Address { get; set; }

        public string? Email { get; set; }

        public byte StoreId { get; set; }

        public bool Active { get; set; }

        public string Username { get; set; } = string.Empty;

        public DateTime LastUpdate { get; set; }

        // 画像が存在するかどうかフラグ（byte[] 直接送るとサイズが大きいため）
        public bool HasPicture { get; set; }
    }
}